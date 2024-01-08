import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

interface Props {
    inverted?: boolean; //darken the background of the loading component if true 
    content?: string; //what text to display in the loading component 
    }

export default function LoadingComponent({inverted = true, content = 'Loading...'}: Props){ 
    return(
        <Dimmer active={true} inverted={inverted}>
            <Loader content={content}/>
        </Dimmer>
    )
}
