# Husky: Commit hooks

## Installation

Automatic mode (recommnded):

The package husky-init is used to quickly install and initialize a project with husky.

From your project root, type the following commands (depending on your package manager) to install husky.

<b>Important:</b> If your package.json is in a subdirectory, see how to set up a custom directory with husky.

```
npx husky-init && npm install       # npm
npx husky-init && yarn              # Yarn 1
yarn dlx husky-init --yarn2 && yarn # Yarn 2+
```

After successful execution of this script several things did happen:
* A folder named <b>.husky</b> in your project root has been added. It contains a file called <b>pre-commit</b>, which is the initial pre-commit hook. And a folder <b>_</b> which contains the automatically generated shell script for husky. (Do not commit this, see <b>.gitignore</b>)
* The <b>package.json</b> was modified, with a <b>prepare</b> script and <b>husky</b> was added as a devDependency.
* And your <b>package-lock.json</b> was updated.

That's it, you are ready to use husky in your React project. 

## Tutorials
[How to add husky to React](https://www.mariokandut.com/how-to-add-husky-to-react/)

[Full Guide: Add Husky to your React Project](https://levelup.gitconnected.com/full-guide-add-husky-to-your-react-project-e049935f20d5)