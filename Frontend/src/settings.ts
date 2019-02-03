class Settings {
    static BackendUrl = process.env.REACT_APP_SERVER_URL || 'http://localhost:5000/';
    static ApplicationCode = process.env.REACT_APP_APPLICATION_CODE || '';
}

export default Settings;
