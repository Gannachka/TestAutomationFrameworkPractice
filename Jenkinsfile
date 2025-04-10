pipeline {
    agent any
    parameters {
        choice(name: 'BROWSER', choices: ['Chrome', 'Firefox', 'Edge'], description: 'Select browser for UI tests')
    }
    triggers {
        // Automatically triggers when there is a change in the branch (via webhooks)
        pollSCM('* * * * *')  // Example: Poll every minute for changes

        // Scheduled Trigger to run daily at midnight UTC
        cron('H H * * *')
    }
    stages {
        stage('Checkout Code') {
            steps {
                script {
                    // Clone the repository
                    checkout scm
                }
            }
        }
       stage('Restore Dependencies') {
      steps {
        sh 'dotnetRestore'
      }
    }
    stage('Build Solution') {
            steps {
                script {
                    echo "Building the .NET Solution..."
                    // Build the solution for the application
                    sh 'dotnetBuild --configuration Release'
                }
            }
        }

        stage('Run UI Tests') {
            steps {
                script {
                    try {
                        echo "Running UI Tests on browser: ${params.BROWSER}"
                        // Set the browser type and execute UI tests
                        sh """
                            export SELECTED_BROWSER=${params.BROWSER}
                            dotnetTest ./Tests.UI/Tests.UI.csproj --framework net8.0 --logger "trx;LogFileName=TestResults.trx"
                        """
                    } finally {
                        // Archive UI test results and screenshots
                        archiveArtifacts artifacts: '**/TestResults/*.trx', allowEmptyArchive: true
                        archiveArtifacts artifacts: './Screenshots/*.png', allowEmptyArchive: true
                    }
                }
            }
        }
    }
    post {
        always {
            echo 'Pipeline execution finished.'
        }
        success {
            echo 'All tests passed successfully!'
        }
        failure {
            echo 'Pipeline failed! Check artifacts for logs and test results.'
        }
    }
}