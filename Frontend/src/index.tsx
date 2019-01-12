import * as React from 'react';
import * as ReactDOM from 'react-dom';
import Index from './pages/index';
import './main.css';
import * as serviceWorker from './serviceWorker';

ReactDOM.render(<Index />, document.querySelector('#root'));

serviceWorker.register();
