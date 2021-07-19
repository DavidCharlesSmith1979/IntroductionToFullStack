import React from 'react';

class CreateUser extends React.Component {
    constructor(props) {
        super(props);
        this.state = {user: { firstName: '', lastName: '' }, users: props.Users };
    
        this.handleFirstNameChange = this.handleFirstNameChange.bind(this);
        this.handleLastNameChange = this.handleLastNameChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
  
    handleFirstNameChange(event) {    
        this.setState(prevState => ({ user: {...prevState.user, firstName: event.target.value }}));
    }
  
    handleLastNameChange(event) {
        this.setState(prevState => ({ user: {...prevState.user, lastName: event.target.value }}));
    }

    handleSubmit(event) {
        alert('A user was submitted: ' + this.state.user);

        fetch('http://localhost:5001/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.state.user),
        })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);

            this.props.AddUser(data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });

        event.preventDefault();
    }
  
    render() {
        return (
            <form onSubmit={this.handleSubmit}>
            <label>
                First Name:
                <input type="text" onChange={this.handleFirstNameChange} />
            </label>
            <label>
                Last Name:
                <input type="text" onChange={this.handleLastNameChange} />
            </label>
            <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default CreateUser;