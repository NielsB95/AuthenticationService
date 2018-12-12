import React from 'react';
import Header from './StrucutreComponents/Header.tsx';
import Footer from './StrucutreComponents/Footer.tsx';
import Block from './StrucutreComponents/Block.tsx';

class App extends React.Component {
    render() {
        return (
            <div>
                <Header headerText='Hello SEM'></Header>

                <Block width={100} bgColor="#00FF00" />
                <div>
                    <Block width={50} bgColor="#FF0000" />
                    <Block width={50} bgColor="#0000FF" />
                </div>
                <Footer></Footer>
            </div >
        );
    }
}

export default App