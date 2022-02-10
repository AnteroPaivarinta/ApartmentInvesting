import React, {useState } from 'react'
import axios from 'axios';
import { useTable } from 'react-table';
import styled from 'styled-components';
import { useEffect } from 'react';

const App = (props) => {

  const Styles = styled.div`
  padding: 1rem;

  table {
    border-spacing: 0;
    border: 1px solid black;

    tr {
      :last-child {
        td {
          border-bottom: 0;
        }
      }
    }

    th,
    td {
      margin: 0;
      padding: 0.5rem;
      border-bottom: 1px solid black;
      border-right: 1px solid black;

      :last-child {
        border-right: 0;
      }
    }
  }
`

  const [text, setText] = useState(0);
  const [price, setPrice] = useState(0);
  const [array, setArray] = useState([]);
  const doFiles=()=> {
    axios.post(`http://localhost:3001/files`)
      .then(res => {
        console.log("Post pyyntö doFils");
        console.log(res);
      })
  }
  let ob;

  


  useEffect(() => {
  const promise = axios.get('http://localhost:3001');
  //this.setState({ myArray: [...this.state.myArray, 'new value'] })
  promise.then(response => {
    console.log("Array length: ", response.data.length);
    console.log("response: ", response);
    const apartments=[];
    

    for(let i=0;i<response.data.length;i++){
      apartments.push({"index": i, "name": response.data[i].name, "price": response.data[i].price, "link": response.data[i].link});
     //const ok=(prevState)=>[...prevState,{"index": i, "name": response.data[i].name, "price": response.data[i].price, "link": response.data[i].link}];

      
    }
    setArray(apartments);
    //console.log("ARRAY_",array[3].name);
  })

}, []); 


const Content=(props)=> {
  let x;
  const [ar, setAr] = useState([]);
  console.log("Content length: ", props.length);
  console.log("COntent arr", props );

  for(let i=1;i<props.length;i++){
    //console.log("Frm content:  ",props[10].name);
    console.log("Indeks "+i+" of "+props.length);
    ar.push(<tr><td>{i}</td><td>{props[i].name}</td> <td>{props[i].price}</td> <td>  <a href={props[i].link}>{props[i].link}</a></td> </tr>)
    

  }
  

  return(ar)
}
const f=Content(array);
console.log("LENGTH: ",f.length);
  return (
 
  <div>
   
<Styles>


<table>
  <thead>
    <tr>
      <th>#</th>
      <th>Adrress</th>
      <th>Square Price</th>
      <th>Link</th>
    </tr>
  </thead>
  <tbody>
    
      {f}
    


  </tbody>

   
  
  </table>
  
  
  </Styles>
  
  <button onClick={doFiles}>Make .txt files</button>
  
  
  
  </div>
  
  )
}


export default App