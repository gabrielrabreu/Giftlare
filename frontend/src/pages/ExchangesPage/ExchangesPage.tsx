import React, { useEffect, useState } from "react";
import { toast } from "react-toastify";

import ExchangeList from "../../components/ExchangeList/ExchangeList";
import exchangeService from "../../services/ExchangeService";
import { ExchangeDto } from "../../interfaces/ExchangeDto";
import { PagedList } from "../../interfaces/PagedList";
import { translate } from "../../translate";

import "./ExchangesPage.css";

const ExchangesPage: React.FC = () => {
  const [pagedExchange, setPagedExchange] =
    useState<PagedList<ExchangeDto> | null>(null);

  useEffect(() => {
    const fetchExchangeOptions = async () => {
      try {
        const options = await exchangeService.paginate();
        setPagedExchange(options);
      } catch (error) {
        let errorMessage = error;
        if (error instanceof Error) {
          errorMessage = error.message;
        }
        toast.error(errorMessage as React.ReactNode);
      }
    };

    fetchExchangeOptions();
  }, []);

  return (
    <div className="exchanges-page">
      <h1>{translate("exchanges.title")}</h1>
      <ExchangeList exchanges={pagedExchange?.data ?? []} />
    </div>
  );
};

export default ExchangesPage;
