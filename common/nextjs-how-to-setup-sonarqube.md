# How to Setup Sonarqube For Your Next.js Application


### Taken from: [https://medium.com/@raditskc/how-to-setup-sonarqube-for-your-next-js-application-2bcf0a33a84e](https://medium.com/@raditskc/how-to-setup-sonarqube-for-your-next-js-application-2bcf0a33a84e)

### Intro


Static code testing software, like SonarQube, is essential to ensure the quality and reliability of software projects. It scans the code base, identifying bugs, vulnerabilities, and code issues, allowing for early detection and resolution. With the ability to identify and resolve issues in Next.js applications, these tools ensure robust, efficient, and maintainable code that builds confidence in performance and stability.

Before configuring SonarQube for your Next.js application, it is important to make sure that your project is ready. This section will guide you through the necessary steps to prepare your Next.js project for seamless integration with SonarQube. We’ll cover the prerequisites, including installing the SonarQube server and creating a SonarQube project specifically for your Next.js application. By following these steps, you’ll be ready to harness the power of SonarQube to analyze and improve the quality of your Next.js codebase.

Create a new SonarQube project, then generate the SonarQube token from “Administration” -> “Security” -> “Users”. Make sure to save the token somewhere safe.

In your Next.js application, create a `sonar-project.properties` file in the root directory. And add the following content to the file:

```
sonar.projectKey=your_project_key
sonar.projectName=your_project_name
sonar.projectVersion=1.0

sonar.sources=.
sonar.sourceEncoding=UTF-8
sonar.exclusions=**/__tests__/**/*, **/*.test.js
sonar.tests=__tests__

sonar.javascript.file.suffixes=.js,.jsx,.ts,.tsx
sonar.typescript.lcov.reportPaths=coverage/lcov-report/lcov.info
```

In GitLab, navigate to your Next.js project’s repository, go to “Settings” -> “CI/CD” -> “Variables”, then add a new variable named SONAR\_TOKEN and set its value to the SonarQube token generated previously.

While in GitHub, go to “Settings” -> “Secrets” -> “New repository secret”. Add a secret named `SONAR_TOKEN` and paste the SonarQube token generated previously.

If you’re using GitLab, in your `.gitlab-ci.yml` file, add the following content:

```
sonarqube-check:
  image: sonarsource/sonar-scanner-cli
  variables:
    SONAR_USER_HOME: "${CI_PROJECT_DIR}/.sonar" # Set the path to SonarQube home directory
  script:
    - sonar-scanner
```

If you’re using GitHub, in `.github/workflows/main.yml` file, add the following content:

```
name: SonarQube Analysis

on:
  push:
    branches:
      - main

jobs:
  sonarqube:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout Repository
        uses: actions/checkout@v2

      - name: Set up Node.js
        uses: actions/setup-node@v2
        with:
          node-version: 18

      - name: Install Dependencies
        run: npm ci

      - name: SonarQube Scan
        uses: sonarsource/sonarqube-scan-action@v1
        with:
          projectBaseDir: .
          token: ${{ secrets.SONAR_TOKEN }}
          extras: |
            sonar.coverage.exclusions=**/__tests__/**/*, **/*.test.js
            sonar.test.inclusions=__tests__/**/*.test.js
```

In a nutshell, integrating SonarQube into your Next.js application provides significant benefits by improving code quality, reliability, and security. By analyzing your code for bugs, vulnerabilities, and code issues, SonarQube helps you identify and fix them early in the development process. Its seamless integration with GitHub and CI/CD processes enables continuous monitoring of code quality, ensuring compliance with best practices. By implementing SonarQube, you are establishing a strong foundation for long-term success, cultivating a culture of excellence in your Next.js project. So don’t hesitate to take advantage of SonarQube’s capabilities to optimize your Next.js application and deliver reliable, high-quality software.


## Additional tutorials

##### GitHub Integration | Mapping your organization into SonarQube
<iframe width="560" height="315" src="https://www.youtube.com/embed/6zvBuZr8CeI?si=Rgp3dxIR775r5Mxc" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>