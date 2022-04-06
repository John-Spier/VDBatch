VirtualDub Batch Assistant (VDBatch)

VDBatch is a simple utility designed to help automate the creation of
VirtualDub .jobs files.  Using VDBatch, you can take one job created
through VirtualDub and apply its settings to an arbitrary number of files.

IMPORTANT:  VDBatch requires the Microsoft .NET runtime library, which
	        is a free download from Microsoft.

.NET security typically prohibits programs from doing much when run
over a network share, so unless you are familiar with .NET security
settings, I recommend running VDBatch on your local machine (otherwise
you may get security exception errors).

===========================================================================
The VDBatch Interface
===========================================================================

When you run VDBatch, you will see three separate panes.  The top pane
(which is initially empty) will contain the list of files to be processed.
You can add files to this list by either clicking on the "Browse" button at
the bottom of the window, or by dropping files directly on to the VDBatch
program.

Note:  Although any type of file may be added to the list via browsing
       or drag-and-drop, only files with the AVI extension will be
       added if you drop an entire directory.  I recommend using the
       "Find Files" function of Windows Explorer if you wish to create
       more complex sets of files for dragging.

The bottom-left panel is a quick set of instructions (primarily a variable
reference).

The bottom-right panel is where your VirtualDub job file template is
displayed.  The default template will take each video file in the
input list and create a new uncompressed video file, adding the "-New"
suffix to the name.

===========================================================================
Creating a Job Template
===========================================================================

To create your own job file template, open up VirtualDub and create one
representative job.  For example, if you want to make a template that takes
a video file and creates a pair of jobs for the first and second pass of a
DivX encoding, you might follow these steps:

1.  Open VirtualDub, and open your AVI file in it
2.  Add any filters you want to use on the file
3.  Set your DivX codec settings, using "2-pass, first pass"
4.  Save your AVI, using the "Add operation to job list and defer
    processing" option on the "Save AVI" dialog.
5.  Change your DivX settings to use "2-pass, second pass"
6.  Save your AVI again, using the same deferred processing option.
7.  Exit VirtualDub.
8.  Open your VirtualDub.jobs file (in the directory in which VirtualDub is
    installed) in your favorite text editor.
9.  Locate the pair of jobs comprising the first and second DivX passes.

The text you need begins with the line "//$job" and ends with the line
"// $endjob"  If you want both passes, be sure to copy both jobs.  What you
have should be similar to the default template you see when VDBatch starts,
except that you will have a very long "SetCompData()" line representing the
DivX compression settings as well.

10.  Edit the text to include variables instead of actual filenames.

This will make your template generic; take a look at the sample template
for a quick overview on where the various variables should be placed.
Don't forget that you aren't limited to saving files in the same directory;
you could, for example, use this line at the beginning of the template:

    VirtualDub.Open("%p",0,0);

in conjunction with this line at the end:

    VirtualDub.SaveAVI("E:\\Video_Files\\Processed\\%f");

in order to output the same filename, but to your "Processed" directory
instead of the original directory.

NOTE:  There are probably some VirtualDub commands you do NOT want to
       include.  In particular, the "subset.Clear()" and
       "subset.AddRange()" commands are not likely to be correct for
       all videos.  VirtualDub will default to processing all frames
       if you omit these two commands, and that is probably what you want.

You may save and load template files with the commands on the File menu,
or the shortcut keys Ctrl+S and Ctrl+O.  If you drag a file with the
extension ".job" onto VDBatch, it will assume it is a template file instead
of a video file, and open it in the template window.

===========================================================================
Variable Processing
===========================================================================

The template variables control which parts of the filename are placed in
which locations of the final VirtualDub.jobs file.  The following variables
are defined:

%p    The full source path
      Example:  E:\videos\source.avi

%P    The full source path using "\\"
      Example:  E:\\videos\\Source.avi

%d	  The full source directory
	  Example:  E:\videos

%D	  The full source directory, using "\\"
	  Example:  E:\\videos
	
%b    The full source path, minus extension
      Example:  E:\videos\source

%B    The full source path, no extension, using "\\"
      Example:  E:\\videos\\source

%f    The source filename
      Example:  Source.avi

%F    The source basename
      Example:  Source

%e    The source extension
      Example:  .avi

%n    The current job number

===========================================================================
Creating the VirtualDub.jobs file
===========================================================================

When you press the "Create Job File" button (or select "Create .jobs
file" from the Edit menu), you will be prompted to provide the
location of your VirtualDub.jobs file.  You may save this file
wherever you like, but VirtualDub will only recognize the file if it
is in the same directory as VirtualDub.exe.  VDBatch will them loop through
all of the files in the file list and apply the template text with variable
substitutions.  The result, if the template is correct, will be a valid
VirtualDub.jobs file that you can then process with VirtualDub.

===========================================================================
Copyright Information
===========================================================================

VDBatch is Copyright 2002 by Eric VanHeest.  It is provided as
freeware with no guarantees of any kind.

If you would like to send comments or bug reports, please mail them to
edv@olagrande.net with an appropriate subject line.

The source code to the program is provided for the sake of anyone wishing
to make modifications to the program or learn about the C# and .NET
programming environment.

