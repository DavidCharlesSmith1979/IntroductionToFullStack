import React from 'react';
import './users.css';

class Users extends React.Component {
    constructor() {
      super();
      this.state = [];
    }

    componentDidMount() {
        // Simple GET request using fetch
        fetch('http://localhost:5001/users')
            .then(response => response.json())
            .then(data => this.setState({ users: data }));
    }

    render() {
        if (this.state.users !== undefined) {
            const listItems = this.state.users.map((user) =>
                <tr key="{user.id}" ><td>{user.id}</td><td>{user.firstName}</td><td>{user.lastName}</td></tr>
            );
            return (
                <table >
                    <tr>
                        <th>Id</th>
                        <th>First</th>
                        <th>Last</th>
                    </tr>
                    {listItems
                }</table>
            );
        } else {
            return null;
        }
    }
  }

export default Users;