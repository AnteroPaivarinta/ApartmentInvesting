
const express = require('express')
const app = express()
const cors = require('cors')
const fs = require('fs')
let notes = [];



const writeFileString=(array)=>{
  const nextline="\r\n"
  let content = '';
  let arrayString =[];
  for(let i=0;i<array.length;i++){
    content=content+array[i].name+" , "+ array[i].price+", "+array[i].link+nextline;
  }
  fs.appendFile('apartments.txt', content, err => {
    if (err) {
      console.error(err)
      return
    }
    //done!
  })

}


const writeFileJson=(array)=>{
  let content = JSON.stringify(array)
  fs.appendFile('apartmentsjson.txt', content, err => {
    if (err) {
      console.error(err)
      return
    }
    //done!
  })

}

app.use(express.json())
app.use(cors())



app.get('/', (req, res) => {
  console.log("HELLO?");
  
  res.json(notes)

})

app.post('/', (req, res) => {
    notes.push(req.body)
    console.log(req.body);
    res.json(req.body)    
})


app.post('/files', (req, res) => {
  console.log("Node.js otti pyynnön vastaan");
  writeFileString(notes);
  writeFileJson(notes);   
})

app.get('/api/notes', (req, res) => {
  res.json(notes)
})

const PORT = 3001
app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`)
})
