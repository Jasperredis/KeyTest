using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Welcome to the key test! You are on the first release.");
Console.WriteLine("Press Ctrl+Alt+Shift+F1 to close the application. ");
Console.WriteLine("You can also press F11 to fullscreen!");
Console.WriteLine("Press Ctrl+Alt+Shift+F2 to enter command mode.");
Console.WriteLine("Please focus the window by clicking it to begin.");
bool run = true;
bool commandMode = false;
bool disableModifier = false;
bool allowCtrl = true;
bool allowAlt = true;
bool allowShift = true;
bool allowStop = true;
bool stopping = false;
bool clearOnKey = false;
bool clearOnCommand = false;
while (run)
{
    {
        if (!commandMode)
        {
            if (!stopping)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                bool Ctrl = (keyInfo.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control;
                bool Alt = (keyInfo.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt;
                bool Shift = (keyInfo.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift;
                if (clearOnKey)
                {
                    Console.Clear();
                }
                if (Ctrl)
                {
                    if (allowCtrl == true)
                    {
                        Console.WriteLine("Ctrl+");
                    }
                }
                if (Alt)
                {
                    if (allowAlt == true)
                    {
                        Console.WriteLine("Alt+");
                    }
                }
                if (Shift)
                {
                    if (allowShift == true)
                    {
                        Console.WriteLine("Shift+");
                    }
                }
                Console.WriteLine($"{keyInfo.KeyChar}, {keyInfo.Key}");
                Console.WriteLine();
                if (keyInfo.Key == ConsoleKey.F1)
                {
                    if (Ctrl)
                    {
                        if (Alt)
                        {
                            if (Shift)
                            {
                                if (allowStop == true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Are you sure you would like to close the key test? (y/n)");
                                    stopping = true;
                                }
                            }
                        }
                    }
                }
                if (keyInfo.Key == ConsoleKey.F2)
                {
                    if (Ctrl)
                    {
                        if (Alt)
                        {
                            if (Shift)
                            {
                                run = false;
                                commandMode = true;
                                Console.WriteLine("You are now in command mode! Enter 'list' to see a list of everything you can do here.");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            while (stopping)
            {
                String stopConfirm = Console.ReadLine();
                if (stopConfirm == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for using the key test. Goodbye!");
                    await Task.Delay(3000);
                    Environment.Exit(0);
                }
                else if (stopConfirm == "n")
                {
                    Console.WriteLine("Okay!");
                    Console.WriteLine();
                    run = true;
                    stopping = false;
                }
                else
                {
                    Console.WriteLine("Please provide an answer that is y (yes) or n (no).");
                    Console.WriteLine();
                }
            }
        }
        while (commandMode)
        {
            String command = Console.ReadLine();
            if (command == "list")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine("You can do the following:");
                Console.WriteLine("  - list");
                Console.WriteLine("Provides a list of all commands.");
                Console.WriteLine();
                Console.WriteLine("  - howRead");
                Console.WriteLine("Explains how to read the outputs given, if you can't already.");
                Console.WriteLine();
                Console.WriteLine("  - disableModifier");
                Console.WriteLine("Disables the ability for the key test to output modifier keys (Ctrl, Alt, Shift)");
                Console.WriteLine("Note that this does not disable these keys from triggering command mode or closing the application,");
                Console.WriteLine("Another note, there is not yet a way to re-enable a modifier key.");
                Console.WriteLine();
                Console.WriteLine("  - lockRun");
                Console.WriteLine("Disables the ability to close the program with Ctrl+Alt+Shift+F1.");
                Console.WriteLine("Using this command while the ability is disabled will re-enable it.");
                Console.WriteLine();
                Console.WriteLine("  - exitCommand");
                Console.WriteLine("Exits command mode.");
                Console.WriteLine();
                Console.WriteLine("  - clear");
                Console.WriteLine("Clears the console.");
                Console.WriteLine();
                Console.WriteLine("  - booleans");
                Console.WriteLine("Shows the values of all booleans. For debugging purposes.");
                Console.WriteLine();
                Console.WriteLine("  - clearOnKey");
                Console.WriteLine("Makes the console clear on a key press. For keeping the console looking clean. Re-run the command to disable this.");
                Console.WriteLine();
                Console.WriteLine("  - clearOnCommand");
                Console.WriteLine("The same as clearOnKey, but the console clears on a command. Re-run the command to disable this.");
                Console.WriteLine();
                Console.WriteLine("There is (possibly) more to come in future updates!");
                Console.WriteLine("NOTE: COMMANDS ARE CASE SENSITIVE!");
                Console.WriteLine();
            }
            else if (command == "howRead")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine("Basic Example (key pressed is a, lowercase)");
                Console.WriteLine("a, A");
                Console.WriteLine("The lowercase 'a' is the character you pressed. This means if you were to type something like F5, it would be null, as F5 is not a character.");
                Console.WriteLine("This is why the uppercase 'A' is useful. This displays the key you typed, so if you type A like in the example, you'd get A. If you type F5, you'd get F5.");
                Console.WriteLine("Why is the character useful?");
                Console.WriteLine("  1. It's case-sensitive. Keys, however, are not case sensitive.");
                Console.WriteLine("  2. It allows for characters like an exclamation mark (!). The key would read as D1.");
                Console.WriteLine("Another basic example.");
                Console.WriteLine("Shift+");
                Console.WriteLine("A, A");
                Console.WriteLine("Here, the difference is that shift was pressed to make an uppercase A. You can use Caps Lock instead if you don't want the 'Shift+'");
                Console.WriteLine("On that topic, modifier keys you press will display above the character/key.");
                Console.WriteLine("Ctrl is on top, Alt is in the middle, and Shift is on the bottom.");
                Console.WriteLine("Another example:");
                Console.WriteLine("Shift+");
                Console.WriteLine("!, D1");
                Console.WriteLine("As explained earlier, the ! is the character, and the key is read as 'D1', and shift was used for the exclamation mark.");
                Console.WriteLine("A final example:");
                Console.WriteLine("Ctrl+");
                Console.WriteLine(", F5");
                Console.WriteLine("Here, Ctrl was pressed along with F5. The comma is from the fact that F5 is not a character, so no character is displayed, and only the comma to seperate the character and key.");
                Console.WriteLine("Thats all! :D");
                Console.WriteLine();
            }
            else if (command == "disableModifier")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine("Which modifier key would you like to disable?");
                Console.WriteLine("Type the name of the modifer, or...");
                Console.WriteLine("Type 'cancel' to cancel the command.");
                Console.WriteLine("Please type in all lowercase.");
                Console.WriteLine();
                disableModifier = true;
            }
            else if (command == "ctrl")
            {
                if (disableModifier == true)
                {
                    allowCtrl = false;
                    Console.WriteLine("Ctrl is now disabled from being outputted.");
                    Console.WriteLine();
                }
            }
            else if (command == "alt")
            {
                if (disableModifier == true)
                {
                    allowAlt = false;
                    Console.WriteLine("Alt is now disabled from being outputted.");
                    Console.WriteLine();
                }
            }
            else if (command == "shift")
            {
                if (disableModifier == true)
                {
                    allowShift = false;
                    Console.WriteLine("Shift is now disabled from being outputted.");
                    Console.WriteLine();
                }
            }
            else if (command == "cancel")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                if (disableModifier == true)
                {
                    disableModifier = false;
                    Console.WriteLine("The disableModifier command has been cancelled.");
                    Console.WriteLine();
                }
            }
            else if (command == "lockRun")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                if (allowStop == true)
                {
                    allowStop = false;
                    Console.WriteLine("Ctrl+Alt+Shift+F1 is now disabled.");
                    Console.WriteLine();
                }
                else
                {
                    allowStop = true;
                    Console.WriteLine("Ctrl+Alt+Shift+F1 is already disabled. It is now re-enabled.");
                    Console.WriteLine();
                }
            }
            else if (command == "exitCommand")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine("You are no longer in command mode.");
                Console.WriteLine();
                Console.WriteLine();
                run = true;
                commandMode = false;
            }
            else if (command == "clear")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine("Clearing console in...");
                Console.WriteLine("3");
                await Task.Delay(1000);
                Console.WriteLine("2");
                await Task.Delay(1000);
                Console.WriteLine("1");
                await Task.Delay(1000);
                Console.Clear();
            }
            else if (command == "booleans")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine($"allowShift: , {run}");
                Console.WriteLine($"allowShift: , {commandMode}");
                Console.WriteLine($"allowShift: , {disableModifier}");
                Console.WriteLine($"allowShift: , {allowCtrl}");
                Console.WriteLine($"allowAlt: , {allowAlt}");
                Console.WriteLine($"allowShift: , {allowShift}");
                Console.WriteLine($"allowStop: , {allowStop}");
                Console.WriteLine($"stopping: , {stopping}");
                Console.WriteLine($"clearOnKey: , {clearOnKey}");
                Console.WriteLine($"clearOnCommand: , {clearOnCommand}");
            }
            else if (command == "clearOnKey")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                if (!clearOnKey)
                {
                    clearOnKey = true;
                    Console.WriteLine("The console will now clear whenever a key is pressed.");
                    Console.WriteLine();
                }
                else
                {
                    clearOnKey = false;
                    Console.WriteLine("clearOnKey is already enabled. It is now disabled.");
                    Console.WriteLine();
                }
            }
            else if (command == "clearOnCommand")
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                if (!clearOnCommand)
                {
                    clearOnCommand = true;
                    Console.WriteLine("The console will now clear whenever a command is used.");
                    Console.WriteLine();
                }
                else
                {
                    clearOnCommand = false;
                    Console.WriteLine("clearOncommand is already enabled. It is now disabled.");
                    Console.WriteLine();
                }
            }
            else
            {
                if (clearOnCommand)
                {
                    Console.Clear();
                }
                Console.WriteLine();
                Console.WriteLine("Whoops! This is not a valid command. Check for the following:");
                Console.WriteLine("  1. The command is actually real. Type 'list' for a list of all commands.");
                Console.WriteLine("  2. The command is capitalized correctly. Commands are case-sensitive!");
                Console.WriteLine("  3. There are no typos. Commands do not have autocorrect!");
                Console.WriteLine();
            }
        }
    }
}

//LICENSE:

//MIT License

//Copyright (c) 2024 Alexander Craig

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.