using System;

internal class Instructions
{
	public Instructions()
	{
	}
    public const string Separator = "--------------------------------------------------------------------------------";
    public const string NoteGeneral_1 = "Enter the file path followed by a process command e.g., c:\\MyFiles\\Joe.json /c";
    public const string NoteGeneral_2 = "Following non case sensitive commands are supported";
    public const string NoteGeneral_3 = "                          [exit] - exit the application";
    public const string NoteGeneral_4 = "                          [cls] - clear the console window";
    public const string NoteGeneral_5 = "                          [/c] - print on the console";
    public const string NoteGeneral_6 = "                          [/d] - store in the database";
    public const string NoteGeneral_7 = "                          [/e] - send an email";
    public const string NoteGeneral_8 = "Supported file types .csv|.txt|.json.";
    public const string NoteGeneral_9 = ":>This application will interpret your command to process";
    public const string NoteGeneral_10 = ":>Hit ? + Enter to get help";

}

internal class ErrorMsg
{
    public ErrorMsg()
    {

    }

    public const string NotaValidCmd = "Not a valid command";
    public const string CmdTypeNotSupported = "Command type not supported";
    public const string InvldFileCntnt = "Invalid file content, check your input file";
    public const string FileNotFnd = "File not found, try again";
    public const string FileFormatErr = "File format not supported";
    public const string InvalidInput = "Not a valid input, try again";
}

internal class Constants
{
    public Constants()
    {

    }

    public const string RegExString = @"^(?:[\w]\:)(\\[A-Za-z_\-\s0-9\.]+)+\.[a-zA-Z]+\s(\/[a-zA-Z])$";
}