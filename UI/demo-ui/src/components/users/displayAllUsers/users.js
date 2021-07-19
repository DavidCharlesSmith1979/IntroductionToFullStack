import React from 'react';
import './users.css';
import CreateUser from '../createUser/createUser'

class Users extends React.Component {
    constructor() {
      super();
      this.state = null;
    }

    componentDidMount() {
        fetch('http://localhost:5001/users')
            .then(response => response.json())
            .then(data => this.setState({ users: data }));
    }

    addUser = (newUser) => {
        this.setState(prevState => ({
            users: [...prevState.users, newUser]
          }))
    }

    render() {
        
        if (this.state !== null) {
            const listItems = this.state.users.map((user) =>
                <tr key="{user.id}" ><td>{user.id}</td><td>{user.firstName}</td><td>{user.lastName}</td></tr>
            );
            return (
                <div>
                    <CreateUser Users={this.state.users} AddUser={this.addUser}/>
                    <table >
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>First</th>
                                <th>Last</th>
                            </tr>
                        </thead>
                        <tbody>
                        {listItems}
                        </tbody>
                    </table>
                </div>
            );
        } else {
            return null;
        }
    }
  }

export default Users;