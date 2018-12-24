import { LogOff } from "../security/Security";

let GetJson = async (url: string, data?: object) => {

    // Initalize the default values.
    let defaultData = {
        headers: {
            Authorization: ''
        }
    };

    // Get the security token from local storage
    let token = localStorage.getItem('token');
    if (token)
        defaultData.headers['Authorization'] = `bearer ${JSON.parse(token)}`


    // Merge the default data with the data from the arguments.
    let mergedData = { ...defaultData, ...data };

    // Fetch!
    return fetch(url, mergedData)
        .then(response => {
            // If the status is 401, do the logoff anyway so we make sure
            // all user data is removed from local storage.
            if (response.status === 401)
                LogOff();

            return response;
        })
        .then(response => response.json());
};

export { GetJson };
