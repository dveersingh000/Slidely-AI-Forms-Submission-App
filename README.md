# Form Submission App

## Description
This project is a Windows Desktop App for form submissions with an Express backend. The frontend is developed in Visual Basic and the backend in TypeScript.

## Features
- Create new form submissions
- View form submissions with navigation
- Submit form data to the backend
- Retrieve form data from the backend
- Keyboard shortcuts for quick access

## Optional Features (Implemented)
- Deletion of submitted forms
- Editing of submitted forms
- Searching forms by email ID

## Setup

### Prerequisites
- Node.js and npm
- Visual Studio with Visual Basic

### Backend Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/SlidelyFormApp.git
   cd SlidelyFormApp

2. Navigate to the backend directory:
   cd backend
   
3. Install the dependencies:
   npm install
   
4. Compile TypeScript files:
   npx tsc

5.  Start the server:
   node dist/index.js
#### The server will run on http://localhost:3000.

### Frontend Setup
- Open the project in Visual Studio.
- Build and run the solution.

# API Endpoints
Ping
- URL: /ping
- Method: GET
- Response: true
Submit
- URL: /submit
- Method: POST
- Body Parameters:
     - name
     - email
     - phone
     - github_link
     - stopwatch_time
Read
- URL: /read
- Method: GET
- Query Parameters: index
Delete
- URL: /delete
- Method: DELETE
- Query Parameters: index
Edit
- URL: /edit
- Method: PUT
- Query Parameters: index
- Body Parameters:
      - name
      - email
      - phone
      - github_link
      stopwatch_time
Search
- URL: /search
- Method: GET
- Query Parameters: email

# Usage
- Create New Submission
   1. Click on Create New Submission.
   2. Fill in the form details.
   3. Use the stopwatch to track time.
   4. Submit the form using the Submit button or Ctrl + S shortcut.
View Submissions
   1. Click on View Submissions.
   2. Navigate through submissions using the Previous and Next buttons or Ctrl + P and Ctrl + N shortcuts.
      
## License
- This project is licensed under the MIT License - see the LICENSE file for details.
