from fastapi import FastAPI
import requests
import reader

app = FastAPI()


@app.get("/")
def _():
    return "Test"


@app.get("/txt")
def _():
    reader.print_csv_content()
    return reader.print_text_content()

@app.get("/csv")
def _():
    return reader.print_csv_content()

@app.get("/xml")
def _():
    return reader.print_xml_content()

@app.get("/json")
def _():
    return reader.print_json_content()

@app.get("/requestDotNetApi")
def _():
    responseCsv = requests.get("http://127.0.0.1:5126/csv").json()
    responseJson = requests.get("http://127.0.0.1:5126/json").json()
    responseXml = requests.get("http://127.0.0.1:5126/xml").json()
    responseTxt = requests.get("http://127.0.0.1:5126/txt").text

    return {"csv": responseCsv, "json": responseJson, "XML": responseXml, "Txt": responseTxt}

