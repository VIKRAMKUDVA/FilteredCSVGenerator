# FilteredCSVGenerator
Things to be done before running or debugging the code.
1. Change the file path in Program.cs

Description:
1. Created a Console Application in .NET v6 to fetch a CSV file from the desired path which is set in Program.cs and generate a new CSV Files with the required columns.
2. Exceptions are handled in each CS File using try and catch block, also a specific class is created to handle exception in a way to capture the exception in the .txt file.
3. LoggerFile.txt will be generated in the filepath where we have our InputCSV File if no such file exists in the directory, if LoggerFile.txt exists it will modify the existing file.
4. Classes with respect to responsibility is being created in order to make it easier for Developers as well as Testers to go through the flow.
5. Unit Test cases are created inorder to capture and check different types of exceptions are handled in proper manner or not.
