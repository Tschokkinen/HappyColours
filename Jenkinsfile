pipeline {
	agent any
	
	stages {
		stage('Checkout') {
			steps {
				git 'https://github.com/Tschokkinen/HappyColours.git'
			}
		}
		stage('Build') {
			steps {
				echo 'Building test'
			}
		}
		stage('Test') {
			steps {
				echo 'Testing...'
			}
		}
	}
