import re
import os

# Sets execution order of all scripts in directory to the same value.

directory = os.getcwd()
input("Directory to scan is '" + directory + "'. Press ^C to abort or any key to continue")
fileNameRegex = re.compile(".cs.meta$")
stringTargetRegex = re.compile("executionOrder: \d+")
newOrder = input("New execution order: ")
replaceText = "executionOrder: " + newOrder

for root, dirs, files in os.walk(directory):
    for filename in files:
        if (fileNameRegex.search(filename) != None):
            filename = os.path.join(root, filename)
            file = open(filename, "r")
            filestring = file.read()
            file.close()
            file = open(filename, "w")
            filestring = stringTargetRegex.sub(replaceText, filestring)
            file.write(filestring)
            file.close()
            
