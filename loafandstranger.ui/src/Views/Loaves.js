import React from "react";
import loafData from "../helpers/data/loavesData";

class Loaves extends React.Component {

    state = {
        loaves: []
    };

    componentDidMount() {
        loafData.GetAllLoaves()
            .then(data => this.setState({ loaves:data }));
    }

    render() {
        let {loaves} = this.state;

        console.log("loaves",loaves);

        const loafCard = (loaf) => {
           return (
                <div>
                    {loaf.type}
                </div>
            )
        };

        let cards = loaves.map(loafCard);
        console.log("cards",cards);

        return (
            <>
            <h2>Loaves</h2>
            {cards}
            </>
        )
    }
}

export default Loaves;