import json
import xml.etree.cElementTree as ET
import csv

base_path = "C:\\KEA\\System Integration\\SystemIntegrationAssignments\\01._Data_Files\\"


def print_text_content():
    text_file = open(base_path + "me.txt")
    content = text_file.read()
    return content.strip("\n")


def print_json_content():
    json_file = open(base_path + "me.json")
    data = json.load(json_file)

    people = []
    for i in data:
        person = {}
        for y in i:
            person.update({y: i[y]})
        people.append(person)

    return people


def print_csv_content():
    with open(base_path + "me.csv", newline='') as csvfile:
        csv_reader = csv.reader(csvfile, delimiter=';', quotechar='|')
        header_row = next(csv_reader)

        headers = []
        for header in header_row:
            headers.append(header)

        people = []
        for row in csv_reader:
            hobbies = row[3].strip('"').split(", ")
            person = {headers[0]: row[0], headers[1]: row[1], headers[2]: row[2], headers[3]: hobbies}
            people.append(person)

        return people


def print_xml_content():
    tree = ET.parse(base_path + "me.xml")
    root = tree.getroot()

    people = []
    person = {}
    for child in root:
        if child.tag != "hobbies":
            person.update({child.tag: child.text})
        else:
            hobbies = []
            for i in child:
                hobbies.append(i.text)
            person.update({child.tag: hobbies})

    people.append(person)

    return people
