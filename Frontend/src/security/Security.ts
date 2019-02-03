import Settings from "../settings";

let localStorage_isAuthenticated = 'isAuthenticated';
let localStorage_user = 'user';
let localStorage_token = 'token'

let LogOff = () => {
    localStorage.removeItem(localStorage_isAuthenticated);
    localStorage.removeItem(localStorage_token);
    localStorage.removeItem(localStorage_user);

    if (window.location.pathname !== '/Login')
        window.location.href = '/Login';
}

let LogIn = async (username: string, password: string) => {
    let data = new URLSearchParams();
    data.append("username", username);
    data.append("password", password);
    data.append("applicationcode", Settings.ApplicationCode);

    return fetch(`${Settings.BackendUrl}Authenticate`, {
        method: 'POST',
        body: data
    })
        .then(response => {
            if (response.status === 401)
                throw new Error("401 - Unauthorized!!");

            if (response.status === 500)
                throw new Error("500 - Something went wrong!");
            return response.json();
        })
        .then(responseData => {
            let { user, token } = responseData;

            localStorage.setItem(localStorage_isAuthenticated, 'true');
            localStorage.setItem(localStorage_user, JSON.stringify(user));
            localStorage.setItem(localStorage_token, JSON.stringify(token));
        });
}

/**
 * This function checks if the user has still all the required information
 * to authenticate itself.
 */
let CanAuthenticate = () => {
    let isAuthenticated = JSON.parse(localStorage.getItem(localStorage_isAuthenticated)!) || false;
    if (!isAuthenticated)
        return false;

    let token = localStorage.getItem(localStorage_token);
    if (token === null)
        return false;

    return true;
}

interface IUser {
    firstname: string,
    lastname: string,
    username: string
}
let GetUser = (): IUser => {
    let rawUser = localStorage.getItem(localStorage_user);

    if (!rawUser)
        return { firstname: "", lastname: "", username: "" }

    let user = JSON.parse(rawUser);
    return user;
}

export { LogOff, LogIn, CanAuthenticate, GetUser };
