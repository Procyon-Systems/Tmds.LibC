namespace Tmds.Linux {

    public static unsafe partial class LibC {

        /*
            A device ID consists of two parts: a major ID, identifying the
            class of the device, and a minor ID, identifying a specific
            instance of a device in that class.  A device ID is represented
            using the type dev_t.

            Given major and minor device IDs, makedev() combines these to
            produce a device ID, returned as the function result.  This
            device ID can be given to mknod(2), for example.

            The major() and minor() functions perform the converse task:
            given a device ID, they return, respectively, the major and minor
            components.  These macros can be useful to, for example,
            decompose the device IDs in the structure returned by stat(2).
         */

        public static uint gnu_dev_major(dev_t dev) {
            return (uint)(((dev >> 8) & 0xfff) | ((uint) (dev >> 32) & ~0xfffLu));
        }

        public static uint gnu_dev_minor(dev_t dev) {
            return (uint)((dev & 0xff) | ((uint) (dev >> 12) & ~0xffLu));
        }

        public static dev_t gnu_dev_makedev(uint major, uint minor) {
            return (
                (minor & 0xff) | ((major & 0xfff) << 8) |
                (((ulong) (minor & ~0xff)) << 12) |
                (((ulong) (major & ~0xfff)) << 32)
            );
        }

        public static dev_t makedev(uint major, uint minor) => gnu_dev_makedev(major, minor);

        /// <summary>
        /// given a device ID, they return, respectively, the major and minor
        /// components.  These macros can be useful to, for example,
        /// decompose the device IDs in the structure returned by stat(2).
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static uint major(dev_t dev) => gnu_dev_major(dev);

        /// <summary>
        /// given a device ID, they return, respectively, the major and minor
        /// components.  These macros can be useful to, for example,
        /// decompose the device IDs in the structure returned by stat(2).
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public static uint minor(dev_t dev) => gnu_dev_minor(dev);

    }

}