let randomNumber = Math.floor(Math.random() * 100) + 1;

const guessField = document.getElementById('guessField');
const submitGuess = document.getElementById('submitGuess');
const message = document.getElementById('message');

let attempts = 0;

function checkGuess() {
  let Guess = parseInt(guessField.value);
  if (Guess == randomNumber) {
    message.textContent = `Glückwunsch! Du hast die Zahl in ${attempts} Versuchen erraten!`;
    message.style.color = 'green';
    submitGuess.disabled = true;
  } else if (Guess < randomNumber) {
    message.textContent = 'Die gesuchte Zahl ist höher!';
    message.style.color = 'red';
  } else {
    message.textContent = 'Die gesuchte Zahl ist niedriger!';
    message.style.color = 'red';
  }
  attempts++;
  if(attempts >= 10) {
    message.textContent = "Du hast verloren, da du 10 Versuche gebraucht hast!";
    message.style.color = 'red';
  }
}

submitGuess.addEventListener('click', checkGuess);
guessField.addEventListener('keydown' , (e) => {
  if(e.keyCode == 13) {
    checkGuess();
  }
});