import { Text } from "@chakra-ui/react";

const PageTitle = ({ children }) => {
  return (
    <Text
      fontWeight="bold"
      color="textDark"
      fontSize="24px"
      letterSpacing="0.3px"
    >
      {children}
    </Text>
  );
};

export default PageTitle;
