#External Contributions

Because of the highly volatile nature of the project in its current state, we
do not currently accept external contributions.

#How to contribute

If you are part of those that can contribute to this project, you must respect
a set of standard practices when doing so. They exists to simplify that we get
the most out of our tools, and that you can easily browse this respoitory.

##Git Commit Messages

We will eventually automate the production of a change log for each of our
releases. This requires us to impose a standard on how git commit messages are
formulated.

### Format of the commit message:
```bash
<type>(<scope>): <subject>

<body>

<footer>
```

## Message subject (first line)
The type and scope should always be lowercase as shown below. There is no
character limit but keep in mind that subjects longer than 80 characters are a
sign of a commit that tries to do too much.

### Allowed `<type>` values:
* **feat** (new feature for the user, not a new feature for build script)
* **fix** (bug fix for the user, not a fix to a build script)
* **docs** (changes to the documentation)
* **style** (formatting, missing semi colons, etc; no production code change)
* **refactor** (refactoring production code, eg. renaming a variable)
* **test** (adding missing tests, refactoring tests; no production code change)
* **chore** (updating grunt tasks etc; no production code change)

### Example `<scope>` values:
* config
* users
* contributions
* communities
* tags
* etc.

The `<scope>` can be empty (eg. if the change is a global or difficult to
assign to a single component), in which case the parentheses are omitted.
Generally, this will match the main API entity related to your changes.

### Message body
The message body is optional for any commit that does not cause a change in
behavior of the production code.

* uses the imperative, present tense: “change” not “changed” nor “changes”
* includes motivation for the change and contrasts with previous behavior

For more info about message body, see:

* http://365git.tumblr.com/post/3308646748/writing-git-commit-messages
* http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html

### Message footer
#### Referencing issues
Closed issues should be listed on a separate line in the footer prefixed with
"Closes" keyword like this:
```bash
Closes #234
```
or in case of multiple issues:
```bash
Closes #123, #245, #992
```

#### Breaking changes
_This section can be ommitted until the first public release._
  
All breaking changes have to be mentioned in footer with the description of the
change, justification and migration notes.
```bash
BREAKING CHANGE:

`port-runner` command line option has changed to `runner-port`, so that it is
consistent with the configuration file syntax.

To migrate your project, change all the commands, where you use `--port-runner`
to `--runner-port`.
```