#include <iostream>
#include <string>
#include "colours.h"
#include <map>

using namespace std;

map<string, int> get_colour_map()
{
    map<string, int> colours;
    colours["black"] = 30;
    colours["red"] = 31;
    colours["green"] = 32;
    colours["yellow"] = 33;
    colours["blue"] = 34;
    colours["magenta"] = 35;
    colours["cyan"] = 36;
    colours["white"] = 37;
    return colours;
}

string modify_text(string inner_text, string colour)
{
    map<string, int> codes = get_colour_map();
    int code = codes[colour];
    return "\033[1;" + to_string(code) + "m" + inner_text + "\033[0m";
}

string red(string text)
{
    return modify_text(text, "red");
}

string blue(string text)
{
    return modify_text(text, "blue");
}

string green(string text)
{
    return modify_text(text, "green");
}

string yellow(string text)
{
    return modify_text(text, "yellow");
}

string magenta(string text)
{
    return modify_text(text, "magenta");
}

string cyan(string text)
{
    return modify_text(text, "cyan");
}

string black(string text)
{
    return modify_text(text, "black");
}

string white(string text)
{
    return modify_text(text, "white");
}