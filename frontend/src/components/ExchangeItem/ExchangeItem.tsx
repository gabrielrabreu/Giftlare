import React from "react";

import { ExchangeDto } from "../../interfaces/ExchangeDto";

import "./ExchangeItem.css";

interface ExchangeItemProps {
  exchange: ExchangeDto;
}

const ExchangeItem: React.FC<ExchangeItemProps> = ({ exchange }) => {
  return (
    <div className="exchange-card">
      <h3>{exchange.name}</h3>
      <p>{exchange.members.length} membros</p>
    </div>
  );
};

export default ExchangeItem;
