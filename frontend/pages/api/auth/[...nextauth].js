import NextAuth from "next-auth";
import GoogleProvider from "next-auth/providers/google";

export default NextAuth({
  providers: [
    GoogleProvider({
      clientId:
        "1095175628672-ntpftasivik2miab3e8f068che204p0v.apps.googleusercontent.com",
      clientSecret: "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",
    }),
  ],
});
