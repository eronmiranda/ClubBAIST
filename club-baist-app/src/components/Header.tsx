import * as React from 'react';

type HeaderProps = {
  text: string
}

function Header(props : HeaderProps){
  return(
    <div className="App-header">
      <h1>{props.text}</h1>
    </div>
  )
}

export default Header;