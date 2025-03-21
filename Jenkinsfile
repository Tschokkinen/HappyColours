pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Checkout the repository
                git 'https://github.com/Tschokkinen/HappyColours.git'
            }
        }
        stage('Build') {
            steps {
                // Add build steps here
                echo 'Building project...'
            }
        }
        stage('Test') {
            steps {
                // Add test steps here
                echo 'Running tests...'
            }
        }
    }
}
