class Settings {
    static BackendUrl = process.env.REACT_APP_SERVER_URL || 'http://localhost:5000/'
}
console.log(process.env);
export default Settings;
