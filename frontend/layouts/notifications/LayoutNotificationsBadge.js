import { Badge } from "@chakra-ui/react";

const LayoutNotificationsBadge = ({ status }) => {
  if (status === 0) {
    return <Badge colorScheme="green">FINALIZADA</Badge>;
  }

  if (status === 1) {
    return <Badge colorScheme="yellow">EM ANDAMENTO</Badge>;
  }

  if (status === 2) {
    return <Badge colorScheme="red">NÃO NOTIFICADO</Badge>;
  }

  return <Badge>NÃO DEFINIDO</Badge>;
};

export default LayoutNotificationsBadge;
