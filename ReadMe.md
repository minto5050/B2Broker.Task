#  B2Broker Test Task

To download and Run the windows binaries
	1. Go to releases and Download the archive
	2. Extract to a location, along with the test data
	3. The program `B2Broker.Task.exe` can be run using windows command prompt.


# Options

To analyze input file for possible anagrams run the program with the following parameters:

`B2Broker.Task.exe --input <inputfile path> --output <output file path> `

eg: `B2Broker.Task.exe --input .\test-data\input.txt --output .\test-data\output.txt`


If you did not provide an input and output path of the file, the program will assume there is an input file 	`input.txt` in the current directory and will process and generate an output file in the same directory,


To generate all possible anagrams for a word using the program, you can run:

 `B2Broker.Task.exe --word <input word> --output <output file path>`

 eg: `B2Broker.Task.exe --word papaya --output anagrams.txt`

To check a number and see whether that number is the
factorial of any numbers in the input file, you can provide the following options to the program:

 `B2Broker.Task.exe --number <number> --input <input file path>`

 eg: `B2Broker.Task.exe --number 39916800 --input .\test-data\input.txt`

 
 Questions:

 # How would you change the design if the input file was very large?**

 The program is designed to process large files, 
 It reads the said files in smaller chunks using `FileStream` and processes them. Chunk size in mega bytes can be specified in the input parameter `--size`

 eg: `B2Broker.Task.exe --input input.txt --output output.txt --size 100`

 # How would you change the design if the input data was bigger than the available
RAM?**

We can adjust the `--size` option to be 50% or less than the size of the RAM.
