import { Flex } from "@chakra-ui/react";

import PageTitle from "components/PageTitle";

const PageLayout = ({ pageTitle, children }) => {
  return (
    <Flex
      width="100%"
      px="30px"
      direction="column"
      minHeight="calc(100vh - 93px)"
    >
      <PageTitle>{pageTitle}</PageTitle>

      {children}
    </Flex>
  );
};

export default PageLayout;
