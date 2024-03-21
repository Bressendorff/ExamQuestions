import json
import xml.etree.cElementTree as ET
import csv
import yaml
from yaml import load
try:
    from yaml import CLoader as Loader
except ImportError:
    from yaml import Loader

base_path = "C:\\GithubRepos\\ExamQuestions\\01a Data parsing servers - Part I\\"


def main():
    print_json_content()
    print_csv_content()
    print_xml_content()
    print_yaml_content()
    print_text_content()


def print_text_content():
    text_file = open(base_path + "me.txt")
    content = text_file.read()
    print(content)


def print_json_content():
    json_file = open(base_path + "me.json")
    data = json.load(json_file)
    for i in data:
        print(i)


def print_csv_content():
    with open(base_path + "me.csv", newline='') as csvfile:
        csv_reader = csv.reader(csvfile, delimiter=';', quotechar='|')
        for row in csv_reader:
            print(', '.join(row))


def print_yaml_content():
    yaml_file = open(base_path + "me.yaml", 'r')
    content = yaml.load(yaml_file, Loader)
    for key, value in content.items():
        print(key, value)


def print_xml_content():
    tree = ET.parse(base_path + "me.xml")
    root = tree.getroot()
    for child in root:
        if child.tag != "hobbies":
            print(child.tag, child.text)
        else:
            print(child.tag)
            for i in child:
                print(" ", i.tag, i.text)


if __name__ == '__main__':
    main()