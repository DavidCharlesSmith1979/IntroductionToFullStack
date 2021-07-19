import React from 'react';
import './users.css';
import CreateUser from '../createUser/createUser'
import UpdateUser from '../updateUser/updateUser'

class Users extends React.Component {
    constructor() {
      super();
      this.state = null;

      this.selectUserToEdit = this.selectUserToEdit.bind(this);
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

    updateUser = (updatedUser) => {
        this.setState(prevState => ({
            users: prevState.users.map(
              el => el.id === updatedUser.id ? updatedUser : el
            )
        }))
        this.setState(prevState => ({
            selectedUser: null
          }))
    }

    selectUserToEdit(event) {
        this.setState({ selectedUser: this.state.users.find(x => x.id === parseInt(event.target.id)) });
    }

    render() {
        
        if (this.state !== null) {
            
            const updateUserItem = this.state.selectedUser !== undefined && this.state.selectedUser !== null ? 
                <UpdateUser User={this.state.selectedUser} UpdateUser={this.updateUser} /> 
                : "";
          
            const listItems = this.state.users.map((user) =>
                <tr key={user.id} >
                    <td>{user.id}</td>
                    <td>{user.firstName}</td>
                    <td>{user.lastName}</td>
                    <td><input type="button" id={user.id} value="Edit" onClick={this.selectUserToEdit} /></td>
                </tr>
            );
            return (
                <div>
                    <CreateUser Users={this.state.users} AddUser={this.addUser}/>
                    {updateUserItem}
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