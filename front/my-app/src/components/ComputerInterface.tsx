// src/components/ComputerInterface.tsx
import React, { useState } from 'react';
import './InterfaceComputer.css'; // Importando o CSS

const ComputerInterface: React.FC = () => {
  const [questionIndex, setQuestionIndex] = useState(0);
  const questions = [
    {
      question: "Você prefere café ou chá?",
      options: ["Café", "Chá"]
    },
    {
      question: "Qual é o seu sistema operacional favorito?",
      options: ["Windows", "Linux", "MacOS"]
    }
  ];

  const handleOptionClick = (option: string) => {
    console.log(`Você escolheu: ${option}`);
    setQuestionIndex(questionIndex + 1);
  };

  return (
    <div className="computer-interface">
      {questionIndex < questions.length ? (
        <div>
          <h1>{questions[questionIndex].question}</h1>
          <div className="options">
            {questions[questionIndex].options.map((option, index) => (
              <button key={index} onClick={() => handleOptionClick(option)}>
                {option}
              </button>
            ))}
          </div>
        </div>
      ) : (
        <h1>Obrigado por participar!</h1>
      )}
    </div>
  );
};

export default ComputerInterface;