import { render, screen } from "@testing-library/react";

import React from "react";

import ViewGroupPage from "./ViewGroupPage";

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useParams: () => jest.fn(),
}));

describe("ViewGroupPage Componente", () => {
  test("renders ViewGroupPage correctly", () => {
    // Arrange
    const mockParams = { groupId: "123" };
    jest
      .spyOn(require("react-router-dom"), "useParams")
      .mockReturnValue(mockParams);

    // Render
    render(<ViewGroupPage />);

    // Assert
    expect(screen.getByTestId("page-title")).toBeInTheDocument();
    expect(screen.getByTestId("page-description")).toBeInTheDocument();
  });
});
