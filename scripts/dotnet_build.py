#!/usr/bin/env python

""" Build the C# solution, reproducing the Makefile's
`dotnet build --nologo --verbosity quiet`. File arguments are ignored -- dotnet
resolves the solution/projects from the working directory. """

import subprocess
import sys


def main():
    """ main entry point """
    sys.exit(subprocess.call(
        ["dotnet", "build", "--nologo", "--verbosity", "quiet"]))


if __name__ == "__main__":
    main()
