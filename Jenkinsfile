pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Checkout the repository
                git branch: 'main', url: 'https://github.com/Tschokkinen/HappyColours.git'
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
        stage('Build Podman Image') {
        	steps {
        		script {
        			// Build Podman image
        			sh 'podman build -t test-image .'
        			}
        		}
        	}
	stage('Run Podman Container') {
            steps {
                script {
                    // Run the Podman container
                    sh 'podman run -d --name test-container-name test-image'
                }
            }
        }
	stage('Stop Podman Container') {
            steps {
                script {
                    // Stop the container
                    sh 'podman stop test-container-name'
                    // Remove the container
                    sh 'podman rm test-container-name'
                }
            }
        }
    }
}
