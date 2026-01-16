from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModelForSeq2SeqLM, pipeline
import os
import time

app = Flask(__name__)

os.environ["HF_HOME"] = "D:\\HuggingFace"
os.environ["TRANSFORMERS_CACHE"] = "D:\\HuggingFace\\transformers"

MODEL_ID = "google/flan-t5-large"

tokenizer = AutoTokenizer.from_pretrained(MODEL_ID)
model = AutoModelForSeq2SeqLM.from_pretrained(MODEL_ID)
gen = pipeline("text2text-generation", model=model, tokenizer=tokenizer, device=-1)

def judge(instruction, message):
    start = time.time()
    inp = (
        instruction.strip()
        + "\n\nText:\n"
        + message.strip()
        + "\n\nAnswer with exactly one word: TRUE or FALSE."
    )
    out = gen(inp, max_new_tokens=8, do_sample=False, num_beams=1, truncation=True)[0]["generated_text"].strip().upper()
    tok = out.split()[0] if out.split() else ""
    if tok not in ("TRUE", "FALSE"):
        if "TRUE" in out and "FALSE" not in out:
            tok = "TRUE"
        elif "FALSE" in out and "TRUE" not in out:
            tok = "FALSE"
        else:
            tok = "FALSE"
    elapsed = time.time() - start
    return tok == "TRUE", tok, out, elapsed

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

        result, label, raw, t = judge(instruction, message)

        return jsonify({
            "result": result,
            "label": label,
            "raw": raw,
            "time": t
        }), 200

    except Exception as e:
        return jsonify({"error": str(e)}), 500

if __name__ == "__main__":
    app.run(host="127.0.0.1", port=5005, threaded=True)
