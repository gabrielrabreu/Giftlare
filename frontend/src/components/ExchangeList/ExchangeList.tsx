import React from "react";

import { ExchangeDto } from "../../interfaces/ExchangeDto";
import ExchangeItem from "../ExchangeItem/ExchangeItem";

import "./ExchangeList.css";

interface ExchangeListProps {
  exchanges: ExchangeDto[];
}

const ExchangeList: React.FC<ExchangeListProps> = ({ exchanges }) => {
  return (
    <div className="exchange-list">
      <h2>Lista de Grupos</h2>
      <div className="exchange-cards">
        {exchanges.map((exchange) => (
          <React.Fragment key={exchange.id}>
            <ExchangeItem exchange={exchange} />
          </React.Fragment>
        ))}
      </div>
    </div>
  );
};
export default ExchangeList;
