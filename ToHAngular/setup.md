# setup
1. install node.js
1. install the angular cli with `npm i -g @angular/cli`

# creating an angular app
1. run CLI command `ng new <app-name>` to scaffold an angular project
1. say yes to everything, then add routing
1. navigate to your scaffolded project and run the command `ng serve --o` to run scaffolded application and open in browser

# scaffolded app
- the command to scaffold a new project gives you a few things. let's talk about the important things
1. package.json
    - tells node.js how to handle our project - metadata about the project
    - if we don't have a node_modules folder, you can run  `npm i` to look into your package and install necessary packages
1. tsconfig.json
    - compiler options for our ts files
1. node_modules folder
    - libraries and dependencies that you'll be working with
1. e2e folder
    - used for end to end testing
1. src folder
    - contains actual source code!