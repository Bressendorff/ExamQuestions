from fastapi import FastAPI, Request
import requests
import json

app = FastAPI()

@app.get("/")
def start():
    r = requests.post("https://localhost:7045/register", json={"Username": "frederik", "CallbackUrl": "http://127.0.0.1:8000/pingTest", "Hook": 1}, verify='localhost-chain.pem')


@app.post("/pingTest")
async def _(request: Request):
    body = await request.body()
    body = json.loads(body)
    print(body)
    return {"result": request.body}

