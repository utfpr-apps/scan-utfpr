import Container from "components/Container";
import PageLayout from "components/PageLayout";

import LayoutRoomsHeader from "./LayoutRoomsHeader";
import LayoutRoomsTable from "./LayoutRoomsTable";

const LayoutRooms = () => (
  <PageLayout pageTitle="Salas e Ambientes">
    <Container my="25px" direction="column" flex={1} p="32px">
      <LayoutRoomsHeader />

      <LayoutRoomsTable />
    </Container>
  </PageLayout>
);

export default LayoutRooms;
