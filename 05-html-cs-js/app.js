const boton_reiniciar = document.getElementById("btn_reiniciar");
const botonEnviar = document.getElementById("btn_enviar");
const input = document.querySelector("#numInput");
const textoPista = document.getElementById("devolucion");
const primerHijo = padre.children[0];
const fila2 = document.getElementById("fila2");
let num_aleatorio = Math.floor(Math.random() * 20) + 1;
const cantIntentos = 15;
let score = cantIntentos;
let highscore = 0;
boton_reiniciar.disabled = true;
textoPista.innerHTML = `Tienes ${cantIntentos} intentos`; 
primerHijo.innerHTML = "Score: "+cantIntentos;

boton_reiniciar.addEventListener("click", function() {
    botonEnviar.disabled = false;
    botonEnviar.classList.remove("btn-secondary");
    boton_reiniciar.classList.remove("btn-danger");
    boton_reiniciar.disabled = true;
    textoPista.innerHTML = "Tiene "+ score +" intentos";
    primerHijo.innerHTML = "Score: "+ score;
    fila2.style.display = "block";
});

botonEnviar.addEventListener("click", function(e) {
    e.preventDefault();
    let num = input.value;
    if (num > 0 && num < 21) {
        const padre = document.getElementById("padre");
        const hijoSiguiente = primerHijo.nextElementSibling;
        

        if (num < num_aleatorio) {
            console.log("Muy bajo");
            textoPista.innerHTML = "Muy bajo";
        }
        else if (num > num_aleatorio) {
            console.log("Muy alto");
            textoPista.innerHTML = "Muy alto";
        }
        else if (num == num_aleatorio) { 
            textoPista.innerHTML = "<h2 class='mt-5 text-primary text-center'>Ganaste!</h2>";
            console.log("Ganaste!");
            primerHijo.innerHTML = "Score: "+(score);
            botonEnviar.classList.add("btn-secondary");
            botonEnviar.disabled = false;
            boton_reiniciar.classList.add("btn-danger");
            boton_reiniciar.disabled = false;
            fila2.style.display = "none";
            if (score > highscore) {
                highscore = score;
                hijoSiguiente.innerHTML = "Highscore: "+(highscore);
            } 
            score = 1;
            num_aleatorio = Math.floor(Math.random() * 10) + 1;
        }
        score--;
        

        if (score === 0 && num == num_aleatorio) {
            score = cantIntentos;
        }    
        else if (score === 0) {
            console.log("Perdiste");
            primerHijo.innerHTML = "Perdiste";
            botonEnviar.classList.add("btn-secondary");
            botonEnviar.disabled = true;
            boton_reiniciar.classList.add("btn-danger");
            boton_reiniciar.disabled = false;
            score = cantIntentos;
        }
        else { 
            boton_reiniciar.disabled = true;
            primerHijo.innerHTML = "Score: "+(score);
            console.log("Le quedan "+ score +" intentos"); 
        }
    }
});