<h2>Post method:</h2> 
addres: <br>
/api/v{version}/Himno <br>
body: <br>
{ <br>
  "number": 0, -> This value can´t be zero <br>
  "name": "string",<br>
  "lyrics": "string",<br>
  "type": "string",<br>
  "clasification": "string", <br>
  "status": "string" -> this property will take the values Waiting or Ready<br>
}<br>

<hr>

<h2>Delete method:</h2>
addres:<br>
/api/v{version}/Himno<br>
body:<br>
{<br>
  "id": 0<br>
}<br>

<hr>

<h2>Update method:</h2>
addres:<br>
/api/v{version}/Himno<br>
body:<br>
{<br>
  "id": 0, <br>
  "number": 0, -> This value can´t be zero<br>
  "name": "string",<br>
  "lyrics": "string",<br>
  "type": "string",<br>
  "clasification": "string",<br>
  "status": "string" -> this property will take the values Waiting or Ready<br>
}<br>

<hr>

<h2>Get method:</h2>
addres:<br>
/api/v{version}/Himno<br>
Query:<br>
can include the value <br>
PageSize and PageNumber<br>
by default the page size is 10<br>

<hr>

<h2>Get method:</h2>
addres:<br>
/api/v{version}/Himno/{id}<br>
The query needs to give a valid Id<br>

<hr>

<h2>Get method:</h2>
addres:<br>
/api/v{version}/Himno/property<br>
Using this method we can get a list of Himnos<br>
with the given parameters on the query, if there´s no parameters<br>
the response will be empty<br>
Parameters that can be included<br>
<ul>
<li>Number : int</li>
<li>Name : string</li>
<li>Lyrics : string</li>
<li>Type : string</li>
<li>Clasification : string</li>
<li>Status : string</li>
</ul>
