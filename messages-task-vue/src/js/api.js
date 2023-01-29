const URL_ROOT = 'http://localhost:8769/api/'; // <--- HERE SET THE URL OF THE API
const URL_LOGIN = URL_ROOT + "Users/login"
const URL_LOGOUT = URL_ROOT + "Users/logout"
const URL_REGISTER = URL_ROOT + "Users/register"
const URL_MESSAGES = URL_ROOT + "Messages"
const URL_USERS = URL_ROOT + "Users"
const URL_USER_NOTIFICATION = URL_ROOT + "UserNotifications/reset"

export class User {
    constructor(id, email, password = undefined, totalNotif = undefined) {
        this.id = id;
        this.email = email;
        this.password = password;
        this.totalNotif = totalNotif;
        }
        id;
        email;
        password;
        totalNotif;
}

export class Message {
    constructor(id, senderEmail, body, userId = undefined) {
        this.id = id;
        this.senderEmail = senderEmail;
        this.body = body;
        this.userId = userId;
        }
        id;
        senderEmail;
        userId;
        body;
}
// get Users
export function api_getUsers(callback) {
    var url = URL_USERS;
    fetch(url)
        .then(response => response.json())
        .then(data => callback(data));
}
// register
export function api_register(user, callback) {
    var url = URL_REGISTER;
    delete user.id;
    console.log("register");
    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user)
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => callback(data));
}
// login
export function api_login(user, callback) {
    var url = URL_LOGIN;
    delete user.id;
    console.log("login");
    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user)
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => callback(data));
}
// logout
export function api_logout(user, callback) {
    var url = URL_LOGOUT;
    console.log("logout");
    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user)
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => callback(data));
}
// get Messages of the user
export function api_getMessages(user, callback) {
    var url = URL_MESSAGES + "/" + user.id;
    fetch(url)
        .then(response => response.json())
        .then(data => callback(data));
}
// send Message
export function api_setMessage(message, callback) {
    var url = URL_MESSAGES;
    delete message.id;
    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(message)
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => callback(data));
}
// reset notification of 1 user
export function api_userNotificationReset(userId, callback) {
    console.log("reset notification of 1 user");
    console.log(userId);
    var url = URL_USER_NOTIFICATION;
    var requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ "userId": userId })
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => callback(data));
}