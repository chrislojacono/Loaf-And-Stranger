import React from "react";
import { Switch, Route } from "react-router-dom";
import Loaves from "../Views/Loaves";

export default function Routes(){
    return (
        <Switch>
            <Route exact path="/loaves" component={Loaves}/>
        </Switch>
    )
}