from fastapi import FastAPI, Response
from fastapi.middleware.cors import CORSMiddleware
from starlette.responses import StreamingResponse
import asyncio
from datetime import datetime

app = FastAPI()

# CORS settings to allow all origins
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],  # Allow requests from any origin
    allow_credentials=True,
    allow_methods=["GET", "POST", "PUT", "DELETE"],  # Allow various HTTP methods
    allow_headers=["*"],  # Allow all headers
)



@app.get("/getCount")
async def get_count():
    async def update_count():
        count = 0
        while True:
            yield f"data: {count}\n\n"
            await asyncio.sleep(1)
            count = count + 1

    return StreamingResponse(update_count(), media_type="text/event-stream")