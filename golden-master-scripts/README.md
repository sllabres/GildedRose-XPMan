Golden Master scripts for the Gilded Rose Kata
==============================================

As an alternative to using the Texttext tool, here are some simple bash scripts to allow you to work using the Golden Master technique.

The Golden Master technique involves pushing a large amount of data through your system and recording the output - the Golden Master.  After each refactoring step, you push the same data set through your code and compare the output to the Golden Master.

Generation
----------

The first job is to generate your Golden Master.  To do this you run the following script:

	generate "<Your command here>" "<output directory>"

For example, to generate the Golden Master for the java example, I run

	generate 'java -classpath ../Java/bin com.gildedrose.TexttestFixture 30' java

The command to run for your choice of language can usually be pinched from the texttests/config.gr file.

Note that you may need to ensure that enough data is pushed through your code.  This is the `30` parameter to the java command above, representing 30 days of updates.  You can check that you have enough data by simply inspecting the Golden Master file that is output.

I've been using the language name as an output directory, so, for example, the above call will generate the `java/golden-master` file.  The file name can't be changed... without hacking the scripts.  Feel free if you want to.

Verification
------------

Once you've made a refactoring, you'll want to check you haven't broken anything.  You need to do:

	verify "<Your command here>" "<output directory>"

Note that the args are identical to that of the `generate` command you used earlier.

You will either get a simple message telling you that your tests pass, or the diffs between the current output and the Golden Master.  If you have failures, fix them or revert to your last safe point.  Running `verify` again will tell you when the behaviour has returned to the original.

Updating
--------

Should you actually want to make a change to the Golden Master to represent a change of functionality (e.g. changing the behaviour of the Conjured Mana Cake) then, assuming you're happy with your diffs from the `verify` command, simply run the `generate` command again. 

Windows
-------

Windows users should use the Power Shell versions of the scripts `generate.ps1` and `verify.ps1`.  Note that you might need to enter `Set-ExecutionPolicy RemoteSigned` into Power Shell to allow it to run scripts.


Scripts originally based on code by Samir Talwar: https://github.com/SamirTalwar/trivia-golden-master
