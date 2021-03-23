# getting started with TypeScript(TS)
## Get node installed on machine
- go to node.js website and get latest stable version of node
## what is node.js
- runtime environment for JS, so you'll be able to run JS scripts outside of the browser
- interpreter/server environment
- comes with an engine that runs your scripts
- and NPM to manage the packages and dependencies you need in js project
#### note: to check if node is properly installed, use command `node -v` in cmd (bash is cool to use)
## create a TS project
1. create a folder to store project
1. navigate into the folder and create a package.json file using command `npm init -y`
    - a package.json file hold various metadata relevant to the project. Used to give information to the package managerthat allows it to identify the project and project dependencies.
1. run the command `npm i typescript -g` to install relevant dependencies and tools to work with typescript globally
    - this is important because we wanna develop with ts
    - cahnge the -g to --save-dev if you wanna install ts locally
1. run the command `tsc --init` to scaffold a tsconfig.json file
    - this initializes a ts project
    - the tsconfig.json file specifies the root files and the compiler options required to compile the project
    - make sure to edit your tsconfig.json to include a place to put the transpiled js in another folder - outputDir
    - also, add in a path for the compile to search for things to compile (your include)
1. write your first .ts file!
    - it's really like js but with types
    - so in ts, the syntax is `name: type`