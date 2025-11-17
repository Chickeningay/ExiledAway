from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModelForCausalLM
import torch
import os
import re

app = Flask(__name__)


os.environ["HF_HOME"] = "D:\\HuggingFace"
os.environ["TRANSFORMERS_CACHE"] = "D:\\HuggingFace\\transformers"

print("Loading Phi-2 model from D:\\HuggingFace ...")
tokenizer = AutoTokenizer.from_pretrained("microsoft/phi-2")
model = AutoModelForCausalLM.from_pretrained("microsoft/phi-2", torch_dtype=torch.float32)
print("✅ Model loaded and ready.\n")

def analyze_sentiment(message: str) -> bool:
    prompt = f"Classify the sentiment of this text as Positive or Negative.\nText: {message}\nAnswer:"
    inputs = tokenizer(prompt, return_tensors="pt")
    outputs = model.generate(**inputs, max_new_tokens=15)
    full_output = tokenizer.decode(outputs[0], skip_special_tokens=True)
    print(f"\n--- Raw model output ---\n{full_output}\n")

    match = re.search(r"answer[:\-]?\s*(positive|negative)", full_output, re.IGNORECASE)
    if match:
        sentiment_str = match.group(1).lower()
        print(f"→ Extracted sentiment: {sentiment_str}")
        return sentiment_str == "positive"

    tail = full_output.strip().split("\n")[-1].lower()
    print(f"→ Fallback sentiment detection: {tail}")
    if "negative" in tail:
        return False
    elif "positive" in tail:
        return True
    else:
        print("⚠️ Could not determine sentiment confidently.")
        return False  

@app.route("/analyze", methods=["POST"])
def analyze():
    try:
        data = request.get_json(force=True)
        if not isinstance(data, dict) or "message" not in data:
            return jsonify({"error": "Missing 'message' field"}), 400

        message = str(data["message"]).strip()
        if not message:
            return jsonify({"error": "Empty message"}), 400

        print(f"Received message: {message}")
        sentiment = analyze_sentiment(message)
        print(f"→ Final Sentiment Result: {sentiment}")
        return jsonify({"positive": sentiment}), 200

    except Exception as e:
        print(f" Error processing request: {e}")
        return jsonify({"error": str(e)}), 500

if __name__ == "__main__":
    app.run(host="127.0.0.1", port=5005)
