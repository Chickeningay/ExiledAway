from flask import Flask, request, jsonify
from transformers import pipeline
import os
import time

app = Flask(__name__)

# -----------------------------
# HuggingFace cache locations
# -----------------------------
os.environ["HF_HOME"] = "D:\\HuggingFace"
os.environ["TRANSFORMERS_CACHE"] = "D:\\HuggingFace\\transformers"

print("Loading BART-MNLI zero-shot classifier...")

# Zero-shot classification pipeline
classifier = pipeline(
    "zero-shot-classification",
    model="facebook/bart-large-mnli",
    device=-1  # CPU
)

print("✅ Model loaded and ready.\n")


# -----------------------------
# Boolean rule analyzer
# -----------------------------
def analyze_boolean(instruction: str, message: str):
    """
    Uses MNLI:
    - premise   = message
    - hypothesis = instruction
    """

    start_time = time.time()

    result = classifier(
        sequences=message,
        candidate_labels=[instruction],
        multi_label=False
    )

    elapsed = time.time() - start_time

    # MNLI logic:
    # entailment -> TRUE
    # contradiction / neutral -> FALSE
    label = result["labels"][0]
    score = float(result["scores"][0])

    boolean_result = label.lower() == "entailment"

    print("\n==============================")
    print(f"Instruction: {instruction}")
    print(f"Message: {message}")
    print(f"MNLI Label: {label}")
    print(f"Confidence: {score:.3f}")
    print(f"⏱ Inference time: {elapsed:.3f} seconds")
    print("==============================\n")

    return boolean_result, score, elapsed


# -----------------------------
# Flask endpoint
# -----------------------------
@app.route("/analyze", methods=["POST"])
def analyze():
    try:
        data = request.get_json(force=True)

        if not isinstance(data, dict):
            return jsonify({"error": "Invalid JSON"}), 400

        instruction = str(data.get("instruction", "")).strip()
        message = str(data.get("message", "")).strip()

        if not instruction or not message:
            return jsonify({"error": "Missing instruction or message"}), 400

        result, confidence, time_taken = analyze_boolean(instruction, message)

        return jsonify({
            "result": result,
            "confidence": confidence,
            "time": time_taken
        }), 200

    except Exception as e:
        print(f"❌ Error: {e}")
        return jsonify({"error": str(e)}), 500


# -----------------------------
# Run server (threaded)
# -----------------------------
if __name__ == "__main__":
    app.run(
        host="127.0.0.1",
        port=5005,
        threaded=True
    )
